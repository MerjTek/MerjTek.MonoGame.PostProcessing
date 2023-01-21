//------------------------------------------------
//
//  MerjTek Post-Processing CrossStiching Shader
//
//------------------------------------------------

#include "_ShaderMacros.fxh"

#define mod(x, y) (x - y * floor(x / y))

// Settings -+=======================================================================+-

float4x4 Projection;
float4x4 View;
bool Invert = false;
float2 ScreenSize;
float StitchingSize = 6.0;

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
	float2 uv = input.TexCoords;
	float4 c = float4(0.0, 0.0, 0.0, 0.0);
	float size = StitchingSize;
	float2 cPos = uv * ScreenSize;
	float2 tlPos = floor(cPos / float2(size, size));
	tlPos *= size;
	int remX = int(mod(cPos.x, size));
	int remY = int(mod(cPos.y, size));
	if (remX == 0 && remY == 0)
		tlPos = cPos;
	float2 blPos = tlPos;
	blPos.y += (size - 1.0);

	if ((remX == remY) ||
		(((int(cPos.x) - int(blPos.x)) == (int(blPos.y) - int(cPos.y)))))
	{
		if (Invert == true)
			c = float4(0.2, 0.15, 0.05, 1.0);
		else
			c = tex2D(PostProcessingSampler, tlPos * float2(1.0 / ScreenSize.x, 1.0 / ScreenSize.y)) * 1.4;
	}
	else
	{
		if (Invert == true)
			c = tex2D(PostProcessingSampler, tlPos * float2(1.0 / ScreenSize.x, 1.0 / ScreenSize.y)) * 1.4;
		else
			c = float4(0.0, 0.0, 0.0, 1.0);
	}

	return c;
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
