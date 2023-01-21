//------------------------------------------------------
//
//  MerjTek Post-Processing Frosted Glass Noise Shader
//
//------------------------------------------------------

#include "_ShaderMacros.fxh"

#define mod(x, y) (x - y * floor(x / y))

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
float2 TexelSize;
float Frequency = 0.115;

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

texture NoiseTextureMap;
sampler NoiseSampler = sampler_state
{
	Texture = (NoiseTextureMap);
	magfilter = LINEAR;
	minfilter = LINEAR;
	mipfilter = LINEAR;
	AddressU = WRAP;
	AddressV = WRAP;
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

float4 spline(float x, float4 c1, float4 c2, float4 c3, float4 c4, float4 c5, float4 c6, float4 c7, float4 c8, float4 c9)
{
	float w1, w2, w3, w4, w5, w6, w7, w8, w9;
	w1 = 0.0;
	w2 = 0.0;
	w3 = 0.0;
	w4 = 0.0;
	w5 = 0.0;
	w6 = 0.0;
	w7 = 0.0;
	w8 = 0.0;
	w9 = 0.0;
	float tmp = x * 8.0;

	if (tmp <= 1.0)
	{
		w1 = 1.0 - tmp;
		w2 = tmp;
	}
	else if (tmp <= 2.0)
	{
		tmp = tmp - 1.0;
		w2 = 1.0 - tmp;
		w3 = tmp;
	}
	else if (tmp <= 3.0)
	{
		tmp = tmp - 2.0;
		w3 = 1.0 - tmp;
		w4 = tmp;
	}
	else if (tmp <= 4.0)
	{
		tmp = tmp - 3.0;
		w4 = 1.0 - tmp;
		w5 = tmp;
	}
	else if (tmp <= 5.0)
	{
		tmp = tmp - 4.0;
		w5 = 1.0 - tmp;
		w6 = tmp;
	}
	else if (tmp <= 6.0)
	{
		tmp = tmp - 5.0;
		w6 = 1.0 - tmp;
		w7 = tmp;
	}
	else if (tmp <= 7.0)
	{
		tmp = tmp - 6.0;
		w7 = 1.0 - tmp;
		w8 = tmp;
	}
	else
	{
		tmp = saturate(tmp - 7.0);
		w8 = 1.0 - tmp;
		w9 = tmp;
	}

	return w1 * c1 + w2 * c2 + w3 * c3 + w4 * c4 + w5 * c5 + w6 * c6 + w7 * c7 + w8 * c8 + w9 * c9;
}

float3 NOISE2D(float2 p)
{
	return tex2D(NoiseSampler, p).rgb;
}

float4 PostProcessingPixelShader(PostProcessingVertexShaderOutput input) : COLOR0
{
	float2 uv = input.TexCoords;
	float2 ox = float2(TexelSize.x, 0.0);
	float2 oy = float2(0.0, TexelSize.y);
	float2 PP = uv - oy;
	float4 C00 = tex2D(PostProcessingSampler, PP - ox);
	float4 C01 = tex2D(PostProcessingSampler, PP);
	float4 C02 = tex2D(PostProcessingSampler, PP + ox);
	PP = uv;
	float4 C10 = tex2D(PostProcessingSampler, PP - ox);
	float4 C11 = tex2D(PostProcessingSampler, PP);
	float4 C12 = tex2D(PostProcessingSampler, PP + ox);
	PP = uv + oy;
	float4 C20 = tex2D(PostProcessingSampler, PP - ox);
	float4 C21 = tex2D(PostProcessingSampler, PP);
	float4 C22 = tex2D(PostProcessingSampler, PP + ox);

	float n = NOISE2D(Frequency * uv).x;
	n = mod(n, 0.111111) / 0.111111;

	float4 result = spline(n, C00, C01, C02, C10, C11, C12, C20, C21, C22);

	return float4(result.rgb, 1.0);
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
