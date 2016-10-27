# Stuart Wyse
# CSE 465 - HW 4

# ----------------------------------------------------------
# CommonCityNames.txt

# read in states and strip newlines
states = [line.rstrip('\r\n') for line in open('states.txt')]

# arrays to store info
linesToSave = []
citiesToSave = []

# find matching states in zipcodes.txt & states.txt
# add entire line to linesToSave if there's a match
with open('zipcodes.txt') as f:
    for line in f:
        count=0
        for word in line.split('\t'):
            count+=1
            if(count == 5):
                for state in states:
                    if word == state:
                        linesToSave.append(line)

# for each matching state, get city and add it to citiesToSave
for l in linesToSave:
    count=0
    for word in l.split('\t'):
        count+=1
        if(count == 4):
            citiesToSave.append(word)

# sort citiesToSave and write to file w/ one city per line
citiesToSave = (sorted(citiesToSave))
fileToWrite = open('CommonCityNames.txt', 'w')

for city in citiesToSave:
    fileToWrite.write(city + '\n')


# ---------------------------------------------------------
# LatLon.txt

# read in zips and strip new lines
zips = [line.rstrip('\r\n') for line in open('zips.txt')]

zipsLines = []
latAndLon = []

# add info for the zipcodes in zips.txt to zipsLines
# no duplicate zipcodes are added to zipsLines
with open('zipcodes.txt') as f:
    for line in f:
        count=0
        for word in line.split('\t'):
            count+=1
            if(count == 2):
                for zip1 in zips:
                    if word == zip1:
                        if not zipsLines:
                            zipsLines.append(line)
                        # before adding, check for duplicate
                        for line2 in zipsLines:
                            count2=0
                            for word2 in line2.split('\t'):
                                count2+=1
                                if(count2 == 2 and word2 != zip1):
                                    zipsLines.append(line)

# get lat and lon of the zipcode entry and add them to latAndLon
for l in zipsLines:
    count=0
    for word in l.split('\t'):
        count+=1
        if(count == 7):
            latAndLon.append(word) # lat
        if(count == 8):
            latAndLon.append(word) # lon

# split the latitudes and longitudes into their own lists
compList = [latAndLon[x:x+2] for x in range(0, len(latAndLon), 2)]
fileToWrite = open('LatLon.txt', 'w')

# write appropriate info to the LatLon.txt file
for setList in compList:
    count = 0
    for setList2 in setList:
        count+=1
        fileToWrite.write(setList2)
        if(count == 1):
            fileToWrite.write(' ')
    fileToWrite.write('\n')
