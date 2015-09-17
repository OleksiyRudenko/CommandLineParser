@cd CommandLineParser/bin/Debug
CommandLineParser
CommandLineParser -help /? -exit
CommandLineParser /help -print abc def "aaa ttt" -k a 1 b 2 c -ooo /? -d -exit
CommandLineParser -print abc def "aaa ttt" -k a 1 b 2 c -ping -print -ooo -exit
CommandLineParser -help -print p1 23456 -k a 1 b 2 c -ping -print p2 abcdef -k O o -print -d -k -ooo /? -exit
CommandLineParser GGGG
CommandLineParser Uuuu -t oOOOO -d dd/MM/yyyy /help -exit
CommandLineParser -print Test exit. Date shouldn't appear -exit -d
CommandLineParser -print Try running commands from console
@cd ../../..
@pause
