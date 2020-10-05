# -*- coding: utf-8 -*-
"""
Created on Mon Oct  5 14:31:33 2020

Support Vectort Machine: https://towardsdatascience.com/support-vector-machine-python-example-d67d9b63f1c8

@author: tvq_huy
"""

import cvxopt
import numpy as np
from matplotlib import pyplot as plt
from sklearn.model_selection import train_test_split
from sklearn.datasets.samples_generator import make_blobs


class Support_Vector_Machine:
    def fit(self, X, Y):
        n_samples, n_features = X.shape
        K = np.zeros((n_samples, n_samples))
        for i in range(n_samples):
            for j in range(n_samples):
                K[i,j] = np.dot(X[i], X[j]) #???
                
        P = cvxopt.matrix(np.outer(Y, Y) * K) # ???
        
        q = cvxopt.matrix(np.ones(n_samples) * -1)
        
        A = cvxopt.matrix(Y, (1, n_samples))

        b = cvxopt.matrix(0.0)
        
        G = cvxopt.matrix(np.diag(np.ones(n_samples) * -1))
        
        h = cvxopt.matrix(np.zeros(n_samples))
        
        solution = cvxopt.solvers.qp(P, q, G, h, A, b)
        
        a = np.ravel(solution['x'])
        
        sv = a > 1e-5
        ind = np.arange(len(a))[sv]
        self.a = a[sv]
        self.sv = X[sv]
        self.sv_y = Y[sv]
        
        self.b = 0
        for n in range(len(self.a)):
            self.b += self.sv_y[n]
            self.b -= np.sum(self.a * self.sv_y * K[ind[n], sv])
        self.b /= len(self.a)
        
        self.w = np.zeros(n_features)
        for n in range(len(self.a)):
            self.w += self.a[n] * self.sv_y[n] * self.sv[n]
            
        def project(self, X):
            return np.dot(X, self.w) + self.b
    
    
        def predict(self, X):
             return np.sign(self.project(X))

def f(x, w, b, c=0):
    return (-w[0] * x - b + c) / w[1]
        
X, Y = make_blobs(n_samples=250, centers=2,
                  random_state=5, cluster_std=0.60)
Y[Y == 0] = -1
tmp = np.ones(len(X))
Y = tmp * Y

X_train, X_test, Y_train, Y_test = train_test_split(X, Y, random_state=0)

plt.scatter(X_train[:, 0], X_train[:, 1], c=Y_train, cmap='winter')
plt.xlabel("x")
plt.ylabel("y")
# svm = Support_Vector_Machine()
# svm.fit(X_train, Y_train)

# """w.x + b = 0"""
# a0 = -4; a1 = f(a0, svm.w, svm.b)
# b0 = 4; b1 = f(b0, svm.w, svm.b)
# plt.plot([a0,b0], [a1,b1], 'k')

# """w.x + b = 1"""
# a0 = -4; a1 = f(a0, svm.w, svm.b, 1)
# b0 = 4; b1 = f(b0, svm.w, svm.b, 1)
# plt.plot([a0,b0], [a1,b1], 'k--')

# """w.x + b = -1"""
# a0 = -4; a1 = f(a0, svm.w, svm.b, -1)
# b0 = 4; b1 = f(b0, svm.w, svm.b, -1)
# plt.plot([a0,b0], [a1,b1], 'k--')