
ComPWNED is a free app that lets you safely check if your password has appeared among 320 million password that have been breached and exposed online. 

The software comes packaged with a compact database of breached passwords. 
- If the application tells you your password is *not* in the list, it means it is not is not among the 320 million breached passwords. 
- If the application tells you that the password is exposed, there is 99.9% chance it has appeared in a list of breached passwords in the past.

The program does **not** access any online database and keeps your password safe!

The full password database (13GBs when uncompressed) is compiled by [Troy Hunt](https://www.troyhunt.com/) and is available at [haveibeenpwned.com](https://haveibeenpwned.com/Passwords).


## Downloads (Beta)
[ComPWNED-Windows-Beta.zip](https://umich.box.com/shared/static/dbqfmsomjscrwyu3wklta6m9u9wbwk97.zip) (for Windows 64-bit)

## How Do I Use It?

No installation is required on Windows 8 and Windows 10. On some earlier versions of Windows you many need to install [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653) first.

1. Simply download the zip[https://umich.box.com/shared/static/dbqfmsomjscrwyu3wklta6m9u9wbwk97.zip] file to your computer (~550MBs). 
2. Unzip the file
3. Run ComPWNED and enter your password.



## Linux and Mac Users macOS
There is python program along with instructions available at [https://github.com/salessa/compwned](https://github.com/salessa/compwned).  Currently there is no graphical implementation for other platforms.


## How Does it Work?
The password list that is shipped with this app is stored as bloom filter. This [link](https://llimllib.github.io/bloomfilter-tutorial/) provides a good description of bloom filters.

The file that is provided has 46,15,205,609 bits and requires 10 independent SHA-1 hash computations to index into it. With this setup, the theoretical false positive probability is 0.1%.

You can view the full source code on [https://github.com/salessa/compwned](https://github.com/salessa/compwned).

## License Agreement

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


Salessawi Ferede Yitbarek
