// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Xuqi/WaterSimple_MaskValue"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[Header(_____Final_____)]_FinalColor("FinalColor", Color) = (1,0.9613913,0.5330188,1)
		_FinalOpacity("FinalOpacity", Range( 0 , 1)) = 0.8
		_FinalIntensity("FinalIntensity", Range( 0 , 5)) = 0
		[Header(_____MainWater_____)]_Texture_Water("Texture_Water", 2D) = "white" {}
		_MainWaterUV("MainWaterUV", Vector) = (1,1,0,0)
		_WaterSpeed("WaterSpeed", Vector) = (0,0,0,0)
		_SecondWaterScaleAndOffset("SecondWaterScaleAndOffset", Vector) = (1,0,0,0)
		[Header(_____Noise_____)]_Texture_Noise("Texture_Noise", 2D) = "white" {}
		_NoiseUV("NoiseUV", Vector) = (1,1,0,0)
		_NoiseValue("NoiseValue", Range( 0 , 2)) = 0
		_NoiseSpeed("NoiseSpeed", Vector) = (0,0,0,0)
		_Texture_MaskValue("Texture_MaskValue", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "UnityShaderVariables.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
		};

		struct SurfaceOutputCustomLightingCustom
		{
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Metallic;
			half Smoothness;
			half Occlusion;
			half Alpha;
			Input SurfInput;
			UnityGIInput GIData;
		};

		sampler2D _Sampler09;
		uniform float4 _Sampler09_ST;
		uniform float4 _FinalColor;
		uniform float _FinalIntensity;
		uniform sampler2D _Texture_Water;
		uniform float2 _WaterSpeed;
		uniform float2 _MainWaterUV;
		uniform sampler2D _Texture_Noise;
		uniform float2 _NoiseSpeed;
		uniform float2 _NoiseUV;
		uniform float _NoiseValue;
		uniform float2 _SecondWaterScaleAndOffset;
		uniform float _FinalOpacity;
		uniform sampler2D _Texture_MaskValue;
		uniform float4 _Texture_MaskValue_ST;
		uniform float _Cutoff = 0.5;

		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			float2 uv_Sampler09 = i.uv_texcoord * _Sampler09_ST.xy + _Sampler09_ST.zw;
			float2 uv_TexCoord27 = i.uv_texcoord * _MainWaterUV;
			float2 panner38 = ( 1.0 * _Time.y * _WaterSpeed + uv_TexCoord27);
			float2 uv_TexCoord3 = i.uv_texcoord * _NoiseUV;
			float2 panner4 = ( 1.0 * _Time.y * _NoiseSpeed + uv_TexCoord3);
			float4 tex2DNode16 = tex2D( _Texture_Noise, panner4 );
			float4 break35 = ( tex2D( _Sampler09, uv_Sampler09 ) * _FinalColor * _FinalIntensity * (tex2D( _Texture_Water, ( float4( panner38, 0.0 , 0.0 ) + ( tex2DNode16 * _NoiseValue ) ).rg )*_SecondWaterScaleAndOffset.x + _SecondWaterScaleAndOffset.y) );
			float2 uv_Texture_MaskValue = i.uv_texcoord * _Texture_MaskValue_ST.xy + _Texture_MaskValue_ST.zw;
			float temp_output_34_0 = ( break35.a * _FinalOpacity * tex2D( _Texture_MaskValue, uv_Texture_MaskValue ).r );
			c.rgb = 0;
			c.a = 1;
			clip( temp_output_34_0 - _Cutoff );
			return c;
		}

		inline void LightingStandardCustomLighting_GI( inout SurfaceOutputCustomLightingCustom s, UnityGIInput data, inout UnityGI gi )
		{
			s.GIData = data;
		}

		void surf( Input i , inout SurfaceOutputCustomLightingCustom o )
		{
			o.SurfInput = i;
			float2 uv_Sampler09 = i.uv_texcoord * _Sampler09_ST.xy + _Sampler09_ST.zw;
			float2 uv_TexCoord27 = i.uv_texcoord * _MainWaterUV;
			float2 panner38 = ( 1.0 * _Time.y * _WaterSpeed + uv_TexCoord27);
			float2 uv_TexCoord3 = i.uv_texcoord * _NoiseUV;
			float2 panner4 = ( 1.0 * _Time.y * _NoiseSpeed + uv_TexCoord3);
			float4 tex2DNode16 = tex2D( _Texture_Noise, panner4 );
			float4 break35 = ( tex2D( _Sampler09, uv_Sampler09 ) * _FinalColor * _FinalIntensity * (tex2D( _Texture_Water, ( float4( panner38, 0.0 , 0.0 ) + ( tex2DNode16 * _NoiseValue ) ).rg )*_SecondWaterScaleAndOffset.x + _SecondWaterScaleAndOffset.y) );
			float2 uv_Texture_MaskValue = i.uv_texcoord * _Texture_MaskValue_ST.xy + _Texture_MaskValue_ST.zw;
			float temp_output_34_0 = ( break35.a * _FinalOpacity * tex2D( _Texture_MaskValue, uv_Texture_MaskValue ).r );
			float4 appendResult31 = (float4(break35.r , break35.g , break35.b , temp_output_34_0));
			o.Emission = appendResult31.xyz;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardCustomLighting keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutputCustomLightingCustom o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputCustomLightingCustom, o )
				surf( surfIN, o );
				UnityGI gi;
				UNITY_INITIALIZE_OUTPUT( UnityGI, gi );
				o.Alpha = LightingStandardCustomLighting( o, worldViewDir, gi ).a;
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18934
1915;1075;1920;1013;818.5325;173.2494;1.470821;True;False
Node;AmplifyShaderEditor.Vector2Node;13;-1504.948,25.0802;Inherit;False;Property;_NoiseUV;NoiseUV;9;0;Create;True;0;0;0;False;0;False;1,1;0.1,3;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-1240.142,-154.647;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;5;-1191.142,341.353;Inherit;False;Property;_NoiseSpeed;NoiseSpeed;11;0;Create;True;0;0;0;False;0;False;0,0;0.27,0.2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;30;-1115.277,-812.428;Inherit;False;Property;_MainWaterUV;MainWaterUV;5;0;Create;True;0;0;0;False;0;False;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PannerNode;4;-987.9943,31.23271;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;28;-837.1814,-18.3667;Inherit;False;Property;_NoiseValue;NoiseValue;10;0;Create;True;0;0;0;False;0;False;0;0.52;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;27;-926.1814,-803.3667;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;16;-850.0383,234.5288;Inherit;True;Property;_Texture_Noise;Texture_Noise;8;0;Create;True;0;0;0;False;1;Header(_____Noise_____);False;-1;None;f193ad24faf9d9147b83c8209f763960;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;39;-929.6362,-615.1357;Inherit;False;Property;_WaterSpeed;WaterSpeed;6;0;Create;True;0;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PannerNode;38;-668.4886,-782.256;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-561.6572,-21.21228;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;7;-1085.677,-444.4515;Inherit;False;493.219;183.5537;MainTexture;1;9;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;25;-521.6814,-241.8667;Inherit;False;2;2;0;FLOAT2;0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;9;-816.4583,-408.6153;Inherit;True;MainTexture;-1;True;1;0;SAMPLER2D;_Sampler09;False;1;SAMPLER2D;0
Node;AmplifyShaderEditor.Vector2Node;37;-145.0186,-95.6587;Inherit;False;Property;_SecondWaterScaleAndOffset;SecondWaterScaleAndOffset;7;0;Create;True;0;0;0;False;0;False;1,0;1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SamplerNode;29;-352.637,-285.0831;Inherit;True;Property;_Texture_Water;Texture_Water;4;0;Create;True;0;0;0;False;1;Header(_____MainWater_____);False;-1;None;f4cbe0a6339a3974c839efb608530b27;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;20;-322.3057,164.6896;Inherit;False;Property;_FinalIntensity;FinalIntensity;3;0;Create;True;0;0;0;False;0;False;0;2.68;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;36;77.9814,-276.6587;Inherit;True;3;0;COLOR;0,0,0,0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;11;-382.8571,-480.1924;Inherit;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;15;-324.268,-33.3628;Inherit;False;Property;_FinalColor;FinalColor;1;0;Create;True;0;0;0;False;1;Header(_____Final_____);False;1,0.9613913,0.5330188,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;185.5698,-5.599121;Inherit;True;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;33;205.176,300.4772;Inherit;False;Property;_FinalOpacity;FinalOpacity;2;0;Create;True;0;0;0;False;0;False;0.8;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;35;463.176,-102.5228;Inherit;False;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SamplerNode;42;-68.69888,516.9385;Inherit;True;Property;_Texture_MaskValue;Texture_MaskValue;15;0;Create;True;0;0;0;False;0;False;-1;None;81d62ef72e2b92a4397076acd1c1f6b8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;520.176,237.4772;Inherit;True;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;8;-1649.977,-425.4515;Inherit;False;0;0;_MainTex;Shader;False;0;5;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;44;815.9849,465.4112;Inherit;False;Constant;_Float2;Float 2;16;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;31;709.176,-123.5228;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;41;-149.3545,236.8755;Inherit;False;Constant;_Float1;Float 1;14;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;21;-132.845,401.0234;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-350.2504,-124.3339;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;23;-594.845,480.0234;Inherit;False;Property;_LerpColor1;LerpColor1;14;0;Create;True;0;0;0;False;0;False;0.4719206,0.9528302,0.837561,1;0.4719205,0.9528301,0.837561,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;22;-472.845,246.0234;Inherit;False;Property;_LerpColor0;LerpColor0;13;0;Create;True;0;0;0;False;0;False;0.2621485,0.3663372,0.4056604,1;0.2621482,0.3663369,0.4056601,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ToggleSwitchNode;40;1.945431,205.8755;Inherit;False;Property;_UseNoiseLerpColor;UseNoiseLerpColor;12;0;Create;True;0;0;0;False;0;False;0;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;46;854.7024,0.1843376;Float;False;True;-1;2;ASEMaterialInspector;0;0;CustomLighting;Xuqi/WaterSimple_MaskValue;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;TransparentCutout;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;13;0
WireConnection;4;0;3;0
WireConnection;4;2;5;0
WireConnection;27;0;30;0
WireConnection;16;1;4;0
WireConnection;38;0;27;0
WireConnection;38;2;39;0
WireConnection;24;0;16;0
WireConnection;24;1;28;0
WireConnection;25;0;38;0
WireConnection;25;1;24;0
WireConnection;29;1;25;0
WireConnection;36;0;29;0
WireConnection;36;1;37;1
WireConnection;36;2;37;2
WireConnection;11;0;9;0
WireConnection;12;0;11;0
WireConnection;12;1;15;0
WireConnection;12;2;20;0
WireConnection;12;3;36;0
WireConnection;35;0;12;0
WireConnection;34;0;35;3
WireConnection;34;1;33;0
WireConnection;34;2;42;1
WireConnection;31;0;35;0
WireConnection;31;1;35;1
WireConnection;31;2;35;2
WireConnection;31;3;34;0
WireConnection;21;0;22;0
WireConnection;21;1;23;0
WireConnection;21;2;16;0
WireConnection;40;0;41;0
WireConnection;40;1;21;0
WireConnection;46;2;31;0
WireConnection;46;10;34;0
ASEEND*/
//CHKSM=AE77D96AB10C2B8A6DD2848F35F9037B0D7A6ACC