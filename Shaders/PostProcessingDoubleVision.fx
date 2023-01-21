//------------------------------------------------
//
//  MerjTek Post-Processing Double Vision Shader
//
//------------------------------------------------

#include "_ShaderMacros.fxh"

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float DoubleVisionRange = 0;

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

float4 PostProcessingPixelShader(PostProcessingVertexShaderOutput input) : COLOR0
{
	float3 texColor = float3(0, 0, 0);

	texColor += tex2D(PostProcessingSampler, input.TexCoords).rgb * 2;
	texColor += tex2D(PostProcessingSampler, input.TexCoords + float2(-DoubleVisionRange, 0)).rgb;
	texColor += tex2D(PostProcessingSampler, input.TexCoords + float2(DoubleVisionRange, 0)).rgb;
	texColor /= 4;

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
