# This file was produced by the NASA Exoplanet Archive  http://exoplanetarchive.ipac.caltech.edu									
# Sat Apr 22 22:51:28 2017									
#									
# COLUMN ra:             RA [sexagesimal]									
# COLUMN dec:            Dec [sexagesimal]									
# COLUMN st_dist:        Distance [pc]									
# COLUMN pl_name:        Planet Name									
# COLUMN pl_masse:       Planet Mass [Earth mass]									
# COLUMN pl_rade:        Planet Radius [Earth radii]									
# COLUMN pl_disc:        Year of Discovery									
# COLUMN pl_status:      Status									
# COLUMN pl_mnum:        Number of Moons in System									
#									


import pandas as pd

planets = pd.read_csv('planets.csv')

print(planets['ra', 'dec', 'st_dist'])]