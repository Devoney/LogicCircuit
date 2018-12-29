# LogicCircuit
C# library that aims to emulate behavior of digital circuits in code.

The reason I started writing the code is the following: I want to understand and fiddle with digital circuitry on how it does certain operations. Therefore I want to be able to 'quickly' verify the behavior of a circuit. With this library you can write components (consisting of logical gates) and 'quickly' verify that it gives the expected output, based on the given input (see the unit tests for instance).

This is different from modeling a digital circuit in a simulator like https://www.circuitlab.com. This library contains no graphic modeller, but circuitlab does not provide a solution to easily test truth tables on the circuitry.

All logic inside this library starts from the following basic operations in C#: **&&** (AND), **||** (OR) and **!** (NOT).
The rest of all the circuits inside this repo solely chains these operation as building blocks in the form of objects. These objects represent gates, and more complex digital components. Just like digital electronic circuits would.

**Why not start with the model of a transistor?**
Because I am still thinking how to model a transistor in such way that it is a nice representation to see how the AND, OR and NOT operations are derived from combining transistors in various ways.
If you have a good idea, please write the code and create a pull request!

So far it contains the following gates and components. Each is covered by unit test.

### Gates

#### Simple
1. NOT
2. AND
3. OR

#### Composite
1. NAND
2. NOR
3. XNOR
4. XOR

### Arithmetic Logic Units (ALU)

#### Adding (e.g. 5 + 54 = 59)
1. Half Adder
2. Full Adder
3. 8-bit Adder
4. Dynamic N-bit Adder (for testing purpose only)

#### Subtracting (e.g. 34-16 = 18  or  23 - 25 = -2)
1. Half subtracter
2. Full subtracter.
3. 8-bit subtracter.

#### Comparing (e.g. 13 == 13 or 7 < 9 or 15 > 23)
1. Less than
2. Greater than
   (Notice that a NXOR is equivalent to 'N equials N' operation.)
3. Comparer (and ChainableComparer: used for making multi-bit comparers).
4. 8-bit comparer