CodeDesigner 3 (Created by Gtlcpimp)


CodeDesigner has finally made its way onto the .NET framework. During the transition it has picked up
a lot more functionality. Combining some syntax from C with the MIPS32 instruction set, it is capable
of so much more possibilities than the original design. The build is not yet completely finished,
however is ready enough to be toyed with (or even build projects with). Here's a look at the updates:

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


You can have as many ELSE IF's as you want as long as you keep them wrapped with those braces! Also
you must note that it utilizes the "at" register (which stands for Assembler Temporary), so avoid
the use of this register at all cost if using the IF statements.

====================================================================================================
3) SWITCH Statements

SWITCH Statements are very similar to the IF statements, however only compares the value of a single
register to multiple cases that are specified. Syntax as follows:

switch (a0)
{
	case 0
	{
		v0 = 0
	}
	case 1
	{
		v0 = 1
	}
	case 2
	{
		v0 = 2
	}
	case 3
	{
		v0 = 3
	}
	case default
	{
		v0 = -1
	}
}

You can have as many cases as you like, with any value you choose. The default is similiar to the ELSE
of an IF statement, it gets executed if none of the cases were true. Since everything is required to
be wrapped in braces, you can have as many lines of code inside the cases as you desire. The SWITCH
also compiles using the "at" register to do comparisons just like the IF statement, so avoid the use
of this register when using a SWITCH.

What the example would compile to is:

beq a0, zero, $000b
ori at, zero, $0001
beq a0, at, $000c
ori at, zero, $0002
beq a0, at, $000d
ori at, zero, $0003
beq a0, at, $000e
ori at, zero, $0000
beq a0, at, $000f
nop
beq zero, zero, $0010
nop
daddu v0, zero, zero
beq zero, zero, $000d
nop
addiu v0, zero, $0001
beq zero, zero, $000a
nop
addiu v0, zero, $0002
beq zero, zero, $0007
nop
addiu v0, zero, $0003
beq zero, zero, $0004
nop
addiu v0, zero, $ffff
beq zero, zero, $0001
nop


====================================================================================================
3) FNC Declarations

You now have the capability to declare functions to save time and energy. Functions must be wrapped
with braces, and you can specify extra stack space if needed for preserving more registers.

Syntax:

fnc MyFunction(EE a0, EE a1, EE a2) \s0,s1,s2,s3,s4
{
    s0 = a0
    s1 = a1
    s2 = a2
    
    /*
        do some stuff
    */
    
    return 1;
}


As you see, you declare "fnc" followed by the name of your function, then in the paranthesis you
can specify any arguments you want it to use. The backslash at the end declares what registers you
want to be preserved onto the stack. The compiler does all of the work for you. You can force the
function to exit by calling "return" followed by whatever value you want to have returned. The return
will place the specified value (or register value) into "v0".

As you can see, this code will compile out to this:


addiu sp, sp, $ffa0
sq ra, $0000(sp)
sq s0, $0010(sp)
sq s1, $0020(sp)
sq s2, $0030(sp)
sq s3, $0040(sp)
sq s4, $0050(sp)
daddu s0, a0, zero
daddu s1, a1, zero
daddu s2, a2, zero
beq zero, zero, $0001
ori v0, zero, $0001
lq ra, $0000(sp)
lq s0, $0010(sp)
lq s1, $0020(sp)
lq s2, $0030(sp)
lq s3, $0040(sp)
lq s4, $0050(sp)
jr ra
addiu sp, sp, $0060


====================================================================================================
3) FOR Loops

FOR loops can help cut down code, and remove the need to always calculate branch values or throwing
labels everywhere. It follows the same concept from C, where you have the syntax:

for (init; condition; increment)
{
    // Code
}

You can use shorthand math in the increment statement. Live code example:

for (a0 = 0; a0 < 100; a0++)
{
    v0++
}

What this would compile to:

daddu a0, zero, zero
addiu at, zero, $0064
subu at, a0, at
bgez at, $0004
nop
addiu v0, v0, $0001
beq zero, zero, $fffa
addiu a0, a0, $0001


====================================================================================================
4) WHILE Loops

WHILE Loops are conditional only loops. While the condition is TRUE, it keeps looping. It can be used
to create an infinite loop:

while (1)
{
    // Code
}

Or an actual conditional loop:

while (a0 < 100)
{
    v0++
}

What this example would compile out to:

addiu at, zero, $0064
subu at, a0, at
bgez at, $0004
nop
addiu v0, v0, $0001
beq zero, zero, $fffa
nop


====================================================================================================
5) BREAK

BREAK has been implemented naturally since we have SWITCH, FOR, and WHILE statements. Yes there is
a MIPS instruction called BREAK already, so what has been done is the compiler checks to see if you
are using the instruction or the command.

break; // Breaks out of current loop (or case)
break(1); // Breaks out of current loop and parent loop (or case)
break(2); // ^ + next parent loop (or case)

So on, so forth. To use the actual MIPS instruction, you must specifically use the syntax for the
instruction itself:

break (00000)



====================================================================================================
6) Compiler Specific "Commands"

Address $00100000 // Specifies code output addressing
Labels: // Declares a label at this current section of the source
setreg v0, $12345678 // Sets a 32 bit value into the register
setfpr f0, $3f800000 // Sets the float register to the 32 bit value
setfloat f0, 5 // Sets the float register to the specified integer value

goto :label
goto $00100000 // Sets a direct branch (or jump if target address is out of branch range)

extern $00100000 funcName(EE t0, EE t1, COP1 f0) // Similiar to FNC only declaring an "external" function
							at the specified memory address so you can call
							to it.

call funcname(s0, s1, s2) // Calls a function you have declared, placing the arguments you specify into the
			corresponding argument registers

define labelName $12345678 // Defines a new label of the specified value

hexcode $12345678 // Directly outputs the value to the code output
print "string" // Prints the string directly to the code output


string labelName "my string" // Creates a string, appends to the END of the code output, preserving its
				memory address in the specified label

padding $20 // Generates 0's in the code output to the specified size


