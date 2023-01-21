//-------------------------------------------
//
//  MerjTek Post-Processing Contrast Shader
//
//-------------------------------------------

#include "_ShaderMacros.fxh"

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float ContrastAmount = 0.5;

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

// Defined in _ShaderMaros.h

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

	texColor.r = saturate(ContrastAmount * (texColor.r - 0.5) + 0.5);
	texColor.g = saturate(ContrastAmount * (texColor.g - 0.5) + 0.5);
	texColor.b = saturate(ContrastAmount * (texColor.b - 0.5) + 0.5);

	return texColor;
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
