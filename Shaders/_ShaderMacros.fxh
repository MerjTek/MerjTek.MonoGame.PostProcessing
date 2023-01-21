//-------------------------
//
//     Shader Macros
//
//-------------------------

#ifdef SM5

#define VS_NAME vs_5_0
#define PS_NAME ps_5_0

#elif SM4

#define VS_NAME vs_4_0
#define PS_NAME ps_4_0

#else

#define VS_NAME vs_3_0
#define PS_NAME ps_3_0

#endif

#define TECHNIQUE(name, vsname, psname) technique name \
{  \
	pass \
	{ \
		VertexShader = compile VS_NAME vsname (); \
		PixelShader = compile PS_NAME psname(); \
	} \
}

struct PostProcessingVertexShaderInput
{
#if SM4 || SM5
	float4 Position : SV_Position0;
#else
	float4 Position : TEXCOORD1;
#endif
	float2 TexCoords : TEXCOORD0;
};

struct PostProcessingVertexShaderOutput
{
#if SM4 || SM5
	float4 Position : POSITION0;
#else
	float4 Position : POSITION;
#endif
	float2 TexCoords : TEXCOORD0;
};