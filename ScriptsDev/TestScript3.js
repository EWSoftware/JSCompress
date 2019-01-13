//=============================================================================
// File    : TestScript1.js
// Author  : Eric Woodruff
// Updated : 07/23/2003

// This contains nothing useful, just a lot of code and declarations to
// test the compressor.  It's pretty horrendous code, but is a good test
// for the compressor to see if it breaks anything.

// Same as second one but without the semi-colons

alert("Starting")

var a, b, c,
    d,  str1  =  "A test string",   str2 = "Another test string"

var strRegExp = /a|b|c/

/* --------------- */
var   reTest = new   RegExp()
reTest.compile(/[ \f\r\t\v]?([\n\/{}()[\];,<>*%&|^!~?:=])[ \f\r\t\v]?/)

/*
 *
 * Multi-line comment block
 *
 */
function    DoStuff()
{
    a = 1
    b= 2
    c =3
    d       =    4

    a = b++ -1

    c = a-- +1

    d=a/b + c *d

    a = 1+ ++b

    c = 2 * --b

    d = a++ - --b

    c = a-- + ++b

    d = a++ / --b

    c = a-- * ++b

    a = b++
        -1

    c = a--
        +1

    d=a/b +
        c *d

    a = 1+
        ++b

    c = 2 *
        --b

    a = b++
        * 5

    c = a--
        / 3

    a = b
        * 5

    c = a
        / 3

    str1 = "A string {\r // "+
           " }\n in two parts /* */ /  /"

    str2  ='\xFF'

    alert("a = " + a + " b = " + b +
          " c = " + c + " d = " + d)
    alert("str1 = " + str1 + "\nstr2 = " + str2)
}

// Skip compression on this section
function Test()
{
    alert("In Test()")
    return true
}

function MoreStuff()
{
    var ar = new Array()

    ar[0] = str1.replace(/[aeiou]/g, "X")

    a = /^\d{5}$/.test(str2)

    b = (a ==true) ?
        1 :
        2

    c = (a== false)
        ? 3
        : 4

    str2 = ar[
        0]

    for(a = 0; a < 5; a++ )
        str1  += ar[0]

    nPos = str2.indexOf( "Something"  )
    if(nPos != -1 && str2.substr(nPos) == ar[ 0 ] || c == true) {
        d = (c  %   10 ==0)
    }

    if(c == 3)
        str2 = "Updated"
    else
        str2 = "Not updated"

    if(c == 4)
        c++
    else if(c == 3)
        str2 += " - Test #1"

    if(a == 5)
        if(b == 2)
            str2 += " - Test #2"

    while(d < 50)
        d += 5

    if(d == 5)   // Empty if
        ;

    for(a = 0; a < 10; a++)     /* Empty for */
        ;

    while(d < 5)        // Empty while
        ;

    do {
        d--
    }
    while(d > 30)

    switch(a)
    {
        case 5:
            str2 += " - Test #3-1"
            break

        case 10:
            str2 += " - Test #3-2"
            break

        default:
            str2 += " - Test #3-3"
            break
    }

    alert("str1 = " + str1 + "\nstr2 = " + str2);
    alert("a = " + a + " b = " + b +
          " c = " + c + " d = " + d)
}

DoStuff()
    Test()
MoreStuff()
    alert("All done!");

/* Conditional compilation.  These will be compressed but the comment
   markers will be left in place. Note that we do need a semi-colon on
   the line above the start of the conditional block as the "/*cc_on"
   needs to appear on its own line. */
/*@cc_on
   /*@if (@_jscript_version >= 5)
      document.write("IE Browser that supports JScript 5+<br/>")
   @elif (@_jscript_version >= 4)
      document.write("IE Browser that supports JScript 4+<br/>")
   @else @*/
      document.write("Non IE Browser (one that doesn't support JScript)<br/>")
   /*@end
@*/
