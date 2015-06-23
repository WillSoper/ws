#Speedtest

This code is designed to monitor the health and performance of a home broadband connection using Python.

Some of the graph work has been inspired by this blog post: 

http://henrytodd.org/notes/2014/graphing-mtr-reports-with-gnuplot/


Notes taken ready to write a blog post:

sudo apt-get install mtr

sudo apt-get install gnuplot

[accept other packages] gnuplot gnuplot-nox groff psutils



mtr www.google.co.uk -c 5 -r -i 1 > mtr_out.txt

cat mtr_out.txt | awk '{print $2"\t"$6}'

#For naming the files correctly:
echo "/home/el/myfile/`date '+%Y_%m_%d__%H_%M_%S'`.ponies"



Think I should be aiming for the following:

1) Output mtr to filename with current date/time
2) awk/grep to get some specific/known/interesting hosts (and skip some intermediates)
3) Either multiple input files to gnuplot or (probably easier -> ) awk/grep to include filename source as a column in an output file
- Different hosts to be different lines?
- Maybe I want to show the trend across given time on multiple days? Stacked bar then...

