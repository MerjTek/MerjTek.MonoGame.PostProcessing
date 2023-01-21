//------------------------------------------------
//
//  MerjTek Post-Processing Crosshatching Shader
//
//------------------------------------------------

#include "_ShaderMacros.fxh"

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float2 CrosshatchOffset = float2(10, 5);
float4 LuminanceThreshold = float4(1.0, 0.7, 0.5, 0.3);

// Texture Information -+============================================================+-

texture PreProcessTextureMap;
sampler PostProcessingSampler = sampler_state
{
	Texture = (PreProcessTextureMap);
	magfilter = POINT;
	minfilter = POINT;
	mipfilter = POINT;
	AddressU = CLAMP;
	AddressV = CLAMP;
};

texture ScreenMaskTextureMap;
sampler ScreenMaskSampler = sampler_state
{
	Texture = (ScreenMaskTextureMap);
	magfilter = POINT;
	minfilter = POINT;
	mipfilter = POINT;
	AddressU = CLAMP;
	AddressV = CLAMP;
};

// Vertex I/O -+=====================================================+-

// Defined in _ShaderMacros.h

// Vertex Shader -+===================================================================+-

PostProcessingVertexShaderOutput PostProcessingVertexShader(PostProcessingVertexShaderInput input)
{
	PostProcessingVertexShaderOutput output;

	// Apply the world and camera matrices to compute the output position.
	float4 viewPosition = mul(input.Position, View);
	output.Position = mul(viewPosition, Projection);

	// Copy across the input texture coordinate.
	output.TexCoords = input.TexCoords;

	return output;
}

// Pixel Shader -+===================================================================+-

float4 PostProcessingPixelShader(PostProcessingVertexShaderOutput input) : COLOR0
{
	float3 texColor = float3(1.0, 1.0, 1.0);
	float4 pos = input.Position;

	float luminance = length(tex2D(PostProcessingSampler, input.TexCoords).rgb);

	if (luminance < LuminanceThreshold.x)
	{
		if (fmod(pos.x + pos.y, CrosshatchOffset.x) == 0.0)
			texColor = float3(0.0, 0.0, 0.0);
	}

	if (luminance < LuminanceThreshold.y)
	{
		if (fmod(pos.x - pos.y, CrosshatchOffset.x) == 0.0)
			texColor = float3(0.0, 0.0, 0.0);
	}

	if (luminance < LuminanceThreshold.z)
	{
		if (fmod(pos.x + pos.y - CrosshatchOffset.y, CrosshatchOffset.x) == 0.0)
			texColor = float3(0.0, 0.0, 0.0);
	}

	if (luminance < LuminanceThreshold.w)
	{
		if (fmod(pos.x - pos.y - CrosshatchOffset.y, CrosshatchOffset.x) == 0.0)
			texColor = float3(0.0, 0.0, 0.0);
	}

	return float4(texColor, 1.0);
}

// Techniques -+=====================================================================+-

technique Default
{
    pass
    {
        AlphaBlendEnable = False;
        CullMode = None;

		VertexShader = compile VS_NAME PostProcessingVertexShader();
        PixelShader = compile PS_NAME PostProcessingPixelShader();
	
		AlphaBlendEnable = True;
		CullMode = CCW;
	}
}
