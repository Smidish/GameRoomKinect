// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32601,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c7dc6d24bfc69354abafc64abc311b75,ntxv:0,isnm:False|UVIN-5084-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32495,y:32793,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT,E-5456-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.259434,c2:0.5328299,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Time,id:1864,x:31591,y:32597,varname:node_1864,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:6648,x:31563,y:32781,ptovrint:False,ptlb:uspeed,ptin:_uspeed,varname:node_6648,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:7672,x:31563,y:32886,ptovrint:False,ptlb:vspeed,ptin:_vspeed,varname:node_7672,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Append,id:3150,x:31822,y:32859,varname:node_3150,prsc:2|A-6648-OUT,B-7672-OUT;n:type:ShaderForge.SFN_Multiply,id:2242,x:31793,y:32678,varname:node_2242,prsc:2|A-1864-T,B-3150-OUT;n:type:ShaderForge.SFN_Add,id:5084,x:32026,y:32642,varname:node_5084,prsc:2|A-1500-OUT,B-2242-OUT;n:type:ShaderForge.SFN_Tex2d,id:1092,x:31705,y:33259,ptovrint:False,ptlb:gradient_tex,ptin:_gradient_tex,varname:node_1092,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1a1dce84a3c0cbd45ba09ec103f5b4dc,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5456,x:32235,y:33236,varname:node_5456,prsc:2|A-6074-A,B-1092-R;n:type:ShaderForge.SFN_Time,id:9849,x:30796,y:32243,varname:node_9849,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5984,x:30796,y:32395,ptovrint:False,ptlb:u_speed_noise,ptin:_u_speed_noise,varname:node_5984,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:596,x:30796,y:32484,ptovrint:False,ptlb:v_speed_noise,ptin:_v_speed_noise,varname:node_596,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Append,id:5236,x:30955,y:32426,varname:node_5236,prsc:2|A-5984-OUT,B-596-OUT;n:type:ShaderForge.SFN_Multiply,id:3636,x:31039,y:32259,varname:node_3636,prsc:2|A-9849-T,B-5236-OUT;n:type:ShaderForge.SFN_TexCoord,id:621,x:31039,y:32103,varname:node_621,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:8786,x:31218,y:32113,varname:node_8786,prsc:2|A-621-UVOUT,B-3636-OUT;n:type:ShaderForge.SFN_Tex2d,id:6288,x:31275,y:32278,ptovrint:False,ptlb:noise_tex,ptin:_noise_tex,varname:node_6288,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5c520ef6004a1f7429439501b3cbbf5e,ntxv:0,isnm:False|UVIN-8786-OUT;n:type:ShaderForge.SFN_Lerp,id:6771,x:31611,y:32176,varname:node_6771,prsc:2|A-8606-UVOUT,B-6288-R,T-8903-OUT;n:type:ShaderForge.SFN_Slider,id:8903,x:31379,y:32460,ptovrint:False,ptlb:noise_ammount,ptin:_noise_ammount,varname:node_8903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7069791,max:1;n:type:ShaderForge.SFN_TexCoord,id:8606,x:31415,y:32016,varname:node_8606,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Lerp,id:1500,x:32252,y:32214,varname:node_1500,prsc:2|A-3704-UVOUT,B-6771-OUT,T-3446-R;n:type:ShaderForge.SFN_Tex2d,id:3446,x:32027,y:32173,ptovrint:False,ptlb:noise_mask,ptin:_noise_mask,varname:node_3446,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:51b244a573464a440a5bd24c2078c737,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:3704,x:32164,y:32050,varname:node_3704,prsc:2,uv:0,uaff:False;proporder:6074-797-6648-7672-1092-5984-596-6288-8903-3446;pass:END;sub:END;*/

Shader "Shader Forge/nextTry" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.259434,0.5328299,1,1)
        _uspeed ("uspeed", Float ) = 0.1
        _vspeed ("vspeed", Float ) = 0.1
        _gradient_tex ("gradient_tex", 2D) = "white" {}
        _u_speed_noise ("u_speed_noise", Float ) = 0.1
        _v_speed_noise ("v_speed_noise", Float ) = 0.1
        _noise_tex ("noise_tex", 2D) = "white" {}
        _noise_ammount ("noise_ammount", Range(0, 1)) = 0.7069791
        _noise_mask ("noise_mask", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _uspeed;
            uniform float _vspeed;
            uniform sampler2D _gradient_tex; uniform float4 _gradient_tex_ST;
            uniform float _u_speed_noise;
            uniform float _v_speed_noise;
            uniform sampler2D _noise_tex; uniform float4 _noise_tex_ST;
            uniform float _noise_ammount;
            uniform sampler2D _noise_mask; uniform float4 _noise_mask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_9849 = _Time;
                float2 node_8786 = (i.uv0+(node_9849.g*float2(_u_speed_noise,_v_speed_noise)));
                float4 _noise_tex_var = tex2D(_noise_tex,TRANSFORM_TEX(node_8786, _noise_tex));
                float4 _noise_mask_var = tex2D(_noise_mask,TRANSFORM_TEX(i.uv0, _noise_mask));
                float4 node_1864 = _Time;
                float2 node_5084 = (lerp(i.uv0,lerp(i.uv0,float2(_noise_tex_var.r,_noise_tex_var.r),_noise_ammount),_noise_mask_var.r)+(node_1864.g*float2(_uspeed,_vspeed)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_5084, _MainTex));
                float4 _gradient_tex_var = tex2D(_gradient_tex,TRANSFORM_TEX(i.uv0, _gradient_tex));
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*_TintColor.rgb*2.0*(_MainTex_var.a*_gradient_tex_var.r));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.5,0.5,0.5,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
