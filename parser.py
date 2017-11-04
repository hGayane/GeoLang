from geolang import *
import re

class GlobalData:
     lineKW = "գիծ"
     pointKW = "կետ"
     triangleKW = "եռանկյուն"
     segmentKW = "աղեղ"
     rectangleKW = "քառանկյուն"
     #regular expressions
     pointRE = '^կետ\s+\d\s\d\s*$'
     simpleRE="\d"
     

class Parser:
    def __init__(self,prog):
        self.prog = prog
        self.exec = Program()
    def parse(self):
         l = self.prog
         shapes = []
         re.compile(GlobalData.pointRE)
         m = re.match(GlobalData.pointRE,l)
         if(m is not None):
             words = l.split()
             x = words[1]
             y = words[2]
             p = Point(int(x),int(y))
             shapes.append(p)
         return shapes

def main():
    print("in main method")
    prog = "կետ 1 2"
    p = Parser(prog)
    shapes = p.parse()
    prog = Program()
    prog.execute(shapes)
        
        
main()