

#version 330 core
out vec4 FragColor;

in vec2 TexCoords;
in vec3 Normal;
in vec3 Position;
uniform vec3 cameraPos;
uniform sampler2D texture_diffuse1;
uniform sampler2D texture_diffuse2;
uniform sampler2D texture_diffuse3;
uniform samplerCube skybox;

void main()
{    
    vec3 I = normalize(Position - cameraPos);
    vec3 R = reflect(I, normalize(Normal));
    vec4 TexColor = texture(texture_diffuse1, TexCoords);// 这里想混合一下死活bug，我焯看不懂了
    //FragColor = TexColor;
    FragColor =  vec4(texture(skybox, R).rgb, 1.0);
}

