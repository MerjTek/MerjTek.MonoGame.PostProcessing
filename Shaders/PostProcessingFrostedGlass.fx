//------------------------------------------------
//
//  MerjTek Post-Processing Frosted Glass Shader
//
//------------------------------------------------

#include "_ShaderMacros.fxh"

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float RandomFactor = 0.05;
float RandomScale = 5.1;
float2 V1 = float2(92., 80.);
float2 V2 = float2(41., 62.);

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

float rand(float2 co)
{
	return frac(sin(dot(co.xy, V1)) + cos(dot(co.xy, V2)) * RandomScale);
}

float4 PostProcessingPixelShader(PostProcessingVertexShaderOutput input) : COLOR0
{
	float2 uv = input.TexCoords;
	float2 rnd = float2(rand(uv.xy), rand(uv.yx));
	return float4(tex2D(PostProcessingSampler, uv + rnd * RandomFactor).rgb, 1.0);
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
