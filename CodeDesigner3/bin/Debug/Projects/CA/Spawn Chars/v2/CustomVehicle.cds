//address $011de490

memalign quad
nop
VEH_ARG_a2:
nop
hexcode $ffffffff
hexcode $050020C7
hexcode $006EBED8
nop
nop
nop
hexcode $00000001
nop
nop
nop

memalign quad
VEH_ARG_00b0:
nop
nop
nop
hexfloat 1
nop
hexfloat 1
nop
nop
hexcode $BF34FDF4
hexcode $80000000
hexcode $3F34FDF4
nop
VEH_ARG_a3:
nop // x
nop // y
nop // z
hexcode $3f800000

memalign quad
VEH_ARG_t0:
hexcode $00000000
hexcode $B3BBBE2F
hexcode $00000000
hexcode $BF800000


CUSTOM_VEHICLE_DATA:
print "multi_turret_humvee2"
nop
nop
print "_16696_M1025_UI_MSG"
nop
nop
nop
hexcode $b68bc4e6
nop
nop
nop
nop
hexcode $00000002
hexcode $00000001
nop
nop
nop
nop
hexcode $beefbeef // x
hexcode $beefbeef // y
hexcode $beefbeef // z

padding $ec

hexcode $ffffffff
nop
hexcode $bf800000
hexcode $3f19999a
hexcode $3f000000
hexcode $3f800000
hexcode $43fa0000
hexcode $43340000
hexcode $3f000000
nop
nop
hexcode $3f000000
padding $50
hexcode $00010001
nop
nop
