import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from scipy.io import loadmat

mat = loadmat("ex6data1.mat")

X = mat["X"]
Y = mat["y"] 
print(Y)
m, n = X.shape[0], X.shape[1]
pos, neg = (Y==1).reshape(m,1), (Y==0).reshape(m,1)
plt.scatter(X[pos[:,0],0],X[pos[:,0],1],c="r",marker="+",s=50)
plt.scatter(X[neg[:,0],0],X[neg[:,0],1],c="y",marker="o",s=50)
print(pos, neg)