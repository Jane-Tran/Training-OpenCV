from PyQt5 import QtWidgets
from PyQt5.QtWidgets import QApplication, QMainWindow
import sys

class MyWindow(QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        self.setGeometry(0, 0, 600, 600)
        self.setWindowTitle("Control 3DViewer By Gesture")
        self.initUI()

    def initUI(self):
        self.label = QtWidgets.QLabel(self)
        self.label.setText("my first label")
        self.label.move(50, 50)

        self.btn = QtWidgets.QPushButton(self)
        self.btn.setText("Click me !")
        self.btn.clicked.connect(self.clicked)
    
    def clicked(self):
        self.label.setText("you press the button")
        self.update()

    def update(self):
        self.label.adjustSize()

def clicked():
    print("clicked !")

def window():
    app = QApplication(sys.argv)
    win = MyWindow()

    win.show()
    sys.exit(app.exec_())

window()