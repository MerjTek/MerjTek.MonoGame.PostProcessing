//------------------------------------------------------------
//
//  MerjTek Post-Processing Monochrome Edge Detection Shader
//
//------------------------------------------------------------

#include "_ShaderMacros.fxh"

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float2 TexelSize;
float4 EdgeColor = float4(0, 0, 0, 1);
float EdgeThreshold = 0.01;
float4 BackgroundColor = float4(1, 1, 1, 1);

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
	float4 texColor = tex2D(PostProcessingSampler, input.TexCoords);
	float4 sampledColor = float4 (0, 0, 0, 0);
	float2 offsets[8] =
	{
		float2(-1, -1), float2(-1, 0), float2(-1, 1), float2(0, -1),
		float2(0, 1), float2(1, -1), float2(1, 0), float2(1, 1)
	};

	for (int i = 0; i < 8; i++)
		sampledColor += tex2D(PostProcessingSampler, input.TexCoords + offsets[i] * TexelSize);

	sampledColor /= 8;

	return lerp(BackgroundColor, EdgeColor, step(EdgeThreshold, length(texColor - sampledColor)));
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
