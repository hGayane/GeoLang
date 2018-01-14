from geolang import *
import re
import codecs

class GlobalData:
     lineKW = "գիծ"
     pointKW = "կետ"
     triangleKW = "եռանկյուն"
     segmentKW = "աղեղ"
     rectangleKW = "քառանկյուն"
     #regular expressions
     pointRE = '^կետ\s+\d+\s\d+\s*$'
     simpleRE="\d"
     

class Parser:
    def __init__(self, file):
        self.file = file
    def parse(self):
         re.compile(GlobalData.pointRE)
         shapes = []
         f = codecs.open(self.file,encoding='utf-8  ')
         for l in f:
             line = l.rstrip()
             m = re.match(GlobalData.pointRE,line)
             if(m is not None):
                 words = line.split()
                 x = words[1]
                 y = words[2]
                 p = Point(int(x),int(y))
                 shapes.append(p)
         return shapes

def main():
    print("in main method")
    file = "point.gl"
    p = Parser(file)
    shapes = p.parse()
    prog = Program()
    prog.execute(shapes)
        
        
main()