class Shape:
    def draw(self):
        print("shape can not be rendered")
        

class Point(Shape):
    def __init__(self,x,y):
        self.x = x
        self.y = y
    def getX(self):
        return self.x
    def getY(self):
        return self.y
    def draw(self):
        print(self.toStr())
    def toStr(self):
        return "< " + str(self.x) + "," + str(self.y) + " > "
    
class Line(Shape):
    def __init__(self,p1,p2):
        self.p1 = p1
        self.p2 = p2
    def draw(self):
        print("line from " + str(self.p1.getX()) + "," 
              + str(self.p1.getY()) + " to " + str(self.p2.getX()) + "," + str(self.p2.getY()) )

class Triangle(Shape):
    def __init__(self,points):
        self.points = points
    def draw(self):
        p1 = self.points[0]
        p2 = self.points[1]
        p3 = self.points[2]
        l1 = Line(p1,p2)
        l2 = Line(p2,p3)
        l3 = Line(p3,p1)
        l1.draw()
        l2.draw()
        l3.draw()
     

class Rectangle:
    def __init__(self,points):
        self.points = points
    def draw(self):
        p1 = self.points[0]
        p2 = self.points[1]
        p3 = self.points[2]
        p4 = self.points[3]
        l1 = Line(p1,p2)
        l2 = Line(p2,p3)
        l3 = Line(p3,p4)
        l4 = Line(p4,p1)
        l1.draw()
        l2.draw()
        l3.draw()
        l4.draw()

class Segment:
    def __init__(self,radius,origin,angle):
        self.radius = radius
        self.origin = origin
        self.angle = angle
    def draw(self):
        print("circle from origin " +  self.origin.toStr() + 
              " with radius " + str(self.radius)
              + " and angle " + str(self.angle))
            

class Program:
    def execute(self,shapes):
        for shape in shapes:
            shape.draw()
        
    
    
# 
# def main():
#     print ('interpretator starting')
#     t = Rectangle([Point(1,2),Point(3,4),Point(5,6),Point(10,8)])
#     s = Segment(1,Point(0,1),45)
#     shapes = [t,s]
#     p = Program()
#     p.execute()
#     
#main()