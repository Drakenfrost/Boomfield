HUD MODIFICATION

Introduction:
-------------------------------------------------------------------
The hud consists of several different areas in which you can place objects (nodes).

They are:

Global
TopLeft
TopRight
BottomLeftStatic
BottomRightStatic
BottomLeftAnimate
BottomRightAnimate

When you place nodes in either of these areas they will gain relative coordinates from the area you placed the node in.
The names of these "parentnodes" are quite selfexplaing and you can test their placement by adding a node to them with 
coodrinates 0,0 to find ther upper left corner.

BottomLeftAnimate and BottomRightAnimate has a built in animation that moves them outwards when needed. The ammount and speed 
of these animation will later on be changable. There are also built in "fade variables" (BottomLeftAlpha, BottomRightAlpha)
that are connected to these animations. They hold the value of '1.0' when the animation is fully extended and '0.0' when 
retracted outwards.


--------------------------------------------------------------------
Creating Nodes:

The commands below lets you create different basic nodes and add them to the hud.
You always have to define wich node you are working on and in wich parent node it exists.


example:

menu.createPictureNode(TopLeft, TestButton, 0, 0, 100, 100) 

//Creates a button (TestButton) with size 100x100 and coordinates 0,0 relative to 'TopLeft' upper left corner.


menu.setPictureNodeTexture(TopLeft, TestButton, Ingame/Icons/NewTexture.tga)

//Sets the texture of Previously created 'TestButton' to NewTexture.tga 
(Note that textures need to be placed in "BF2\Content\Menu\HUD\Texture")



PictureNodes:

menu.createPictureNode(ParentNode, NodeName, X, y, width, height) 
menu.setPictureNodeTexture(ParentNode, NodeName, Texture path)
menu.setPictureNodeShowVariable(ParentNode, NodeName, VariableName) 
menu.setPictureNodeRotateVariable(ParentNode, NodeName, VariableName) 
menu.setPictureNodeAlphaVariable(ParentNode, NodeName, VariableName)


BarNodes:

menu.createBarNode(ParentNode, NodeName, Direction Up/Down/Left/Right (0/1/2/3), x, y, width, Height)
menu.setBarNodeTexture(ParentNode, NodeName, Background/Foregound (0/1), Texture path)
menu.setBarNodeBorder(ParentNode, NodeName, Left, Right, Top, Bottom) //Sets how much smaller the "bar" in the foregrouns is relative the entire node size.
menu.setBarNodeShowVariable(ParentNode, NodeName, VariableName)
menu.setBarNodeValueVariable(ParentNode, NodeName, VariableName)
menu.setBarNodeAlphaVariable(ParentNode, NodeName, VariableName)


ButtonNodes

menu.createButtonNode(ParentNode, NodeName, x, y, width, height)
menu.setButtonNodeTexture(ParentNode, NodeName, Idle/MouseOver (0/1), Texture path)
menu.setButtonNodeShowVariable(ParentNode, NodeName, std::string)
menu.setButtonNodeFunction(ParentNode, NodeName, VariableName) //Sets which function that will be executed upon mouseclick.
menu.setButtonNodeMouseArea(ParentNode, NodeName, x offset, y offset, width, height) //Sets where the button will react to mouse input.


General Commands:

menu.setNodeColor(ParentNode, NodeName, R, G, B, Alpha)
menu.setNodePos(ParentNode, NodeName, x, y)
menu.setNodeSize(ParentNode, NodeName, width, height)
menu.deleteNode(ParentNode, NodeName,
menu.searchNodes(ParentNode, NodeName(* for all))


Game Commands:

menu.setMouseTexture(std::string)
menu.setCommMouseSensitivity(int)
menu.toggleRightBar(void)
menu.toggleLeftBar(void)


Test Commands:

menu.toggleShowTest(void)




