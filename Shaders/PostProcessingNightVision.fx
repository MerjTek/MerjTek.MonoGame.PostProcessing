//-----------------------------------------------
//
//  MerjTek Post-Processing Night Vision Shader
//
//-----------------------------------------------

#include "_ShaderMacros.fxh"

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float ColorAmplification = 4.0;
float LuminanceThreshold = 0.3;

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
	float3 texColor = tex2D(PostProcessingSampler, input.TexCoords).rgb;
	float mask = tex2D(ScreenMaskSampler, input.TexCoords).r;

	// Enhance the luminance for darker pixels
	float luminance = dot(float3(0.30, 0.59, 0.11), texColor);
	if (luminance < LuminanceThreshold)
		texColor *= ColorAmplification;

	// Tint our screen colors and apply the mask
	float3 visionColor = float3(0.1, 0.95, 0.2);
	texColor.rgb = texColor.rgb * visionColor * mask;

	return float4(texColor, 1);
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
