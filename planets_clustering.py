# This file was produced by the NASA Exoplanet Archive  http://exoplanetarchive.ipac.caltech.edu
# Sun Apr 23 00:52:53 2017
#
# CONSTRAINT:  where (st_dist > 0
# CONSTRAINT:  )
#
# COLUMN ra:             RA [sexagesimal]
# COLUMN dec:            Dec [sexagesimal]
# COLUMN st_dist:        Distance [pc]
# COLUMN pl_name:        Planet Name
# COLUMN pl_rvamp:       Radial Velocity Amplitude [m/s]
# COLUMN pl_masse:       Planet Mass [Earth mass]
# COLUMN pl_msinie:      Planet M*sin(i) [Earth mass]
# COLUMN pl_rade:        Planet Radius [Earth radii]
# COLUMN pl_rads:        Planet Radius [Solar radii]
# COLUMN pl_disc:        Year of Discovery
# COLUMN pl_status:      Status
# COLUMN pl_mnum:        Number of Moons in System
#
								


import pandas as pd
from mpl_toolkits.mplot3d import Axes3D
import matplotlib.pyplot as plt
import numpy as np
from sklearn.cluster import DBSCAN
from sklearn import metrics
import time
import math

planets = pd.read_csv('planets.csv')
planets = planets[planets['st_dist'] < 200]

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

x = planets['ra']
y = planets['dec']
z = planets['st_dist']

ax.scatter(x, y, z, c='r', marker='o')

ax.set_xlabel('Ra Degrees')
ax.set_ylabel('Dec Degrees')
ax.set_zlabel('Distance')


plt.show()

for eps in np.linspace(0.1,1,10):
    for min_sample in range(1, 10, 1):
        X = planets[['ra', 'dec', 'st_dist']]
        db = DBSCAN(eps=eps, min_samples=min_sample).fit(X)
        core_samples_mask = np.zeros_like(db.labels_, dtype=bool)
        core_samples_mask[db.core_sample_indices_] = True
        labels = db.labels_
        n_clusters_ = len(set(labels)) - (1 if -1 in labels else 0)
        print('Number of clusters: {}'.format(n_clusters_))
        # if(len(set(labels)) != 0):
        #     print("Silhouette Coefficient: %0.3f" % metrics.silhouette_score(X, labels))

        unique_labels = set(labels)
        colors = plt.cm.Spectral(np.linspace(0, 1, len(unique_labels)))
        for k, col in zip(unique_labels, colors):
            if k == -1:
                col = 'k'

            class_member_mask = (labels == k)


            xy = X[class_member_mask & core_samples_mask]
            # print(xy)
            # plt.plot(xy[:, 0], xy[:, 1], 'o', markerfacecolor=col,
            #         markeredgecolor='k', markersize=14)
            ax.scatter(xy['ra'], xy['dec'], xy['st_dist'], c=col, marker='o', s=14)

            xy = X[class_member_mask & ~core_samples_mask]
            # plt.plot(xy[:, 0], xy[:, 1], 'o', markerfacecolor=col,
            #         markeredgecolor='k', markersize=6)
            ax.scatter(xy['ra'], xy['dec'], xy['st_dist'], c=col, marker='o', s=6)

        plt.show()