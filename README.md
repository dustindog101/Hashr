# Hashr


This program quickly computes hashes from text and files

USAGE:
this program can either be used by the command line or as a stand alone console application.
if used as a console application the program will detect if you entered a file path or if you entered text and will display its hash.

commandline args are -h,-a,-t,-f

-a sets the algorithm it should hash the input with
-t sets the input type to text
-f sets the input type to a file
-h displays a help screen

examples:hashr.exe -a SHA1 -t this text will be hashed
OUTPUT:SHA1: c2543fff3bfa6f144c2f06a7de6cd10c0b650cae

Currently the program only supports SHA1 but other algorithms are coming very soon.

Screenshots of program in use:
![image](https://user-images.githubusercontent.com/56493866/116942755-3579ef00-ac40-11eb-9ad1-dda0119f926a.png)

![image](https://user-images.githubusercontent.com/56493866/116943725-2431e200-ac42-11eb-9f48-8e43f857cda6.png)
