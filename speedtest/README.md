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

