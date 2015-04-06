#version 330

in vec3 vertexPos;
out vec4 outColor; //out indicates we're passing it to the Frag shader, their names need to match (between Frag and here)

uniform mat4 modelview; //Notice how this matches the string inside glGetUniform or w/e from the setup?
uniform vec4 outputColor;

void main()
{
	outColor = outputColor;
	gl_Position = modelview * vec4(vertexPos, 1.0);
}