define NODE_POINT $006e68e0
define CAllocator_LIP $00706358
define CWorld $01884b00

CUSTOM_NODE_1:

hexcode :NODE_POINT
nop // Allocator ID
nop
nop

// Object Rotations
hexcode $3f800000 // Rotation z1
hexcode $00000000 // Rotation y1 ?
hexcode $00000000 // Rotation x1

nop
nop
hexcode $3f800000 // Rotation y2 ?
nop
nop
hexcode $00000000 // Rotation x2
hexcode $00000000 // Rotation y ?
hexcode $3f800000 // Rotation z2
nop

// Position On Map
hexfloat 7201 // Coordinate X
hexfloat 0 // Coordinate Y
hexfloat 2902 // Coordinate Z

hexcode $3f800000 // ?

// Child Node List
hexcode :CUSTOM_NODE_1_ChildNodeList_START // start
hexcode :CUSTOM_NODE_1_ChildNodeList_END // stop
hexcode :CUSTOM_NODE_1_ChildNodeList_END // stop
hexcode :CAllocator_LIP

// CDI Poly List
hexcode :CUSTOM_NODE_1_CdiPolyList_START // Start
hexcode :CUSTOM_NODE_1_CdiPolyList_END // Stop
hexcode :CUSTOM_NODE_1_CdiPolyList_END // Stop
hexcode :CAllocator_LIP

nop
hexcode :CUSTOM_NODE_1_CVisualList_START // Point to CVisual Pointer
hexcode :CWorld // Point to CWorld

// Dunno
hexcode $0001951a
hexcode $00010001
hexcode $0000beef
nop

// Point to alloc stack with node pointer
nop // Point to allocator stack ^
hexcode $0010ff01
hexcode $80504441

// CVisual List
hexcode :CUSTOM_NODE_1_CVisualList_START // Start
hexcode :CUSTOM_NODE_1_CVisualList_END // Stop
hexcode :CUSTOM_NODE_1_CVisualList_END // Stop
hexcode :CAllocator_LIP
nop
hexfloat 1 // Opacity
hexfloat -0.002 // ?
hexfloat -0.126 // ?
hexfloat -0.9385 // ?
hexfloat 20 // Collission [Width]
hexfloat 26 // Collission [Height]
hexfloat 0.002 // ?
hexcode $08060000 // ???
nop

CUSTOM_NODE_1_ChildNodeList_START:
CUSTOM_NODE_1_ChildNodeList_END:

CUSTOM_NODE_1_CdiPolyList_START:
CUSTOM_NODE_1_CdiPolyList_END:

CUSTOM_NODE_1_CVisualList_START:
hexcode $016a1360
CUSTOM_NODE_1_CVisualList_END:


