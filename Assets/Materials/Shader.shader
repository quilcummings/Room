Shader "Julien/VertexColorMask"
{
    //Properties appear in the inspector
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SecondaryTex ("Secondary (Masked) Texture", 2D) = "black" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //Pull the properties into the CGPROGRAM
        fixed4 _Color;
        sampler2D _MainTex;
        sampler2D _SecondaryTex;
        half _Glossiness;
        half _Metallic;

        struct Input
        {
            float2 uv_MainTex; //Vertex UVs
            float2 uv_SecondaryTex;
            float4 vertexColor : COLOR; //Vertex color
        };
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 diffuse = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            //The secondary texture comes from the vertex colors
            fixed4 secondary = tex2D(_SecondaryTex, IN.uv_SecondaryTex);
            diffuse = lerp(diffuse, secondary, 1 - IN.vertexColor.r);
            
            o.Albedo = diffuse.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = diffuse.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
