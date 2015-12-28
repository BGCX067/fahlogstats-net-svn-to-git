@echo off
rem Runs parsing in interactive mode but redirects output to text file
rem This can be used to test correctness of parsing of HTML after
rem making changes to code -- some subtle errors are best discovered this way
cd ..
bin\debug\htmlparser.exe nodelay >tests\test1.txt
cd tests