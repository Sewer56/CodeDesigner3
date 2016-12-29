CodeDesigner 3 (Created by Gtlcpimp)


CodeDesigner has finally made its way onto the .NET framework. During the transition it has picked up
a lot more functionality. Combining some syntax from C with the MIPS32 instruction set, it is capable
of so much more possibilities than the original design. The build is not yet completely finished,
however is ready enough to be toyed with (or even build projects with). Here's a look at the updates:

------====== New implementations ======------

====================================================================================================
1) Shorthand Math

Yes! Finally! Shorthand math! I bet we are all sick of seeing all those ADDIU's and what not. Well
you can't replace them entirely just yet, shorthand math is limited to 16 Bit integer math. So you'll
still need those hideous LUI's and ADDIU's for larger values. Here's what we have for short handing:

++ // Register + 1
-- // Register - 1
+= // Register + Value (or another register)
-= // Register - Value (or another register)

Here's some examples:

a0++ // Increases the value of a0 by 1
a0-- // Decreases the value of a0 by 1
a0 += 50 // Increase the value of a0 by 50
a0 -= v0 // Decrease the value of a0 by the value of v0


Oh and don't forget bit shifting!

>> // Shift right X bits (srl)
<< // Shift left X bits (sll)
>>> // DOUBLE shift right X bits (dsrl)
<<< // DOUBLE shift left X bits (dsll)
>>32 // DOUBLE shift right X bits times 32 (dsrl32)
<<32 // DOUBLE shift right X bits times 32 (dsll32)

Examples:

a0 >> 10 // Shifts the 32 bit word value in a0 to the right by 10 bits
v0 << 4 // Shifts the 32 bit word value in v0 to the left by 4 bits
t0 >>> 16 // Shifts the 64 bit double word value in t0 to the right by 16 bits
t1 <<< 16 // Shifts the 64 bit double word value in t1 to the left by 16 bits
v0 >>32 0 // Shifts the 64 bit double word value in v0 to the right by 32 bits
v1 <<32 0 // Shifts the 64 bit double word value in v1 to the left by 32 bits


Shorthand math is super simple, and can be implemented virtually everywhere in your project. What
would we do without it? It makes life so much easier.

====================================================================================================
2) IF Statements

There are multiple ways to declare an IF statement. You can either do a single instruction IF or a
multiple instruction IF. The difference is literally in the braces. If you do not include braces
after declaring IF, it will compile it as a single instruction. If you do include the braces, it
compiles as a multiple instruction IF. Here is the syntax for the declaration:

//Single Instruction IF
if (condition)
    //ONE (ONLY ONE) Instruction goes here 

// Multiple Instruction IF
if (condition)
{
    /*
        As many instructions as your heart desires can go here
    */
}

The conditions are very simple:

> Greater than
< Less than
>= Greather than or equal to
<= Less than or equal to
== Is equal to
<> Does not equal

Live code examples:

//Single Instruction IF
if (a0 > t3)
    v0 = 1

// Multiple Instruction IF
if (v0 <= 0)
{
    a0 += 4
    lw v0, $0000(a0)
    /*
        Etc.
    */
}


Now we can't forget about our ELSE statements, yes we have those too! They follow the exact same 
guidelines as the IF declarations, with the exact same syntax. All except for the ELSE itself,
of course. ELSE IF is used for an extra conditional statement, as many times as you need. The
ELSE statement itself however, is the fallback condition for if the IF did not execute. Here's
the examples:

// Single Instruction IF/ELSE
if (a0 > 0)
    lw v0, $0000(a0)
else
    v0 = -1

Single Instruction IF's can be combined with a Single Instruction ELSE only. You cannot use ELSE IF
here. That is reserved for the multi-instruction declaration (literally just add braces).

// Multi-conditional IF/ELSE IF/ELSE
if (a0 == 1)
{
    v0 = 1
}
else if (a0 == 2)
{
    v0 = 2
}
else if (a0 == 3)
{
    v0 = 3
}
else
{
    v0 = 0
}

What this code gets compiled out to is this:

addiu at, zero, $0001
beq a0, at, $0007
addiu at, zero, $0002
beq a0, at, $0008
addiu at, zero, $0003
beq a0, at, $0009
nop
beq zero, zero, $000a
nop
addiu v0, zero, $0001
beq zero, zero, $0008
nop
addiu v0, zero, $0002
beq zero, zero, $0005
nop
addiu v0, zero, $0003
beq zero, zero, $0002
nop
daddu v0, zero, zero


You can have as many ELSE IF's as you want as long as you keep them wrapped with those braces!

====================================================================================================
3) SWITCH Statements







