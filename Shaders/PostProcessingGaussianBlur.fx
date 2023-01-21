//------------------------------------------------
//
//  MerjTek Post-Processing Gaussian Blur Shader
//
//------------------------------------------------

#include "_ShaderMacros.fxh"

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float2 TexelSize;
int BlurRadius = 0;
float GaussianFilter[64];

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

float4 GaussianBlurHorizontalPostProcessingPixelShader(PostProcessingVertexShaderOutput input) : COLOR0
{
	float3 texColor = float3(0, 0, 0);
	int halfBlurRadius = BlurRadius / 2.0;

	float weightTotal = 0;

	for (int i = 0; i < BlurRadius; i++)
	{
		float xOffset = (i - halfBlurRadius) * TexelSize.x;
		float weight = ((float[4])(GaussianFilter[i / 4.0]))[i % 4.0];
		weightTotal += weight;
		texColor += tex2D(PostProcessingSampler, input.TexCoords + float2(xOffset, 0.0f)).rgb * weight;
	}

	texColor /= weightTotal;

	return float4(texColor, 1.0);
}

float4 GaussianBlurVerticalPostProcessingPixelShader(PostProcessingVertexShaderOutput input) : COLOR0
{
	float3 texColor = float3(0, 0, 0);
	int halfBlurRadius = BlurRadius / 2.0;

	float weightTotal = 0;

	for (int i = 0; i < BlurRadius; i++)
	{
		float yOffset = (i - halfBlurRadius) * TexelSize.y;
		float weight = ((float[4])(GaussianFilter[i / 4.0]))[i % 4.0];
		weightTotal += weight;
		texColor += tex2D(PostProcessingSampler, input.TexCoords + float2(0.0f, yOffset)).rgb * weight;
	}

	texColor /= weightTotal;

	return float4(texColor, 1.0);
}

// Techniques -+=====================================================================+-


technique Default
{
	pass Pass0
	{
		AlphaBlendEnable = False;
		CullMode = None;

		VertexShader = compile VS_NAME PostProcessingVertexShader();
		PixelShader = compile PS_NAME GaussianBlurHorizontalPostProcessingPixelShader();
	}

	pass Pass1
	{
		VertexShader = compile VS_NAME PostProcessingVertexShader();
		PixelShader = compile PS_NAME GaussianBlurVerticalPostProcessingPixelShader();
	
		AlphaBlendEnable = True;
		CullMode = CCW;
	}
}
