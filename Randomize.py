import os
import random
currentDir = os.path.realpath(__file__).replace(os.path.basename(__file__),'')
files = os.listdir(currentDir+"CommandMenus")
randomFiles = os.listdir(currentDir+"CommandMenus")
random.shuffle(randomFiles)
output = "assets:\r"
for i in range(len(files)):
    output += "- name: field2d\jp\{0}\r  method: copy\r  source:\r  - name: CommandMenus\{1}\r".format(files[i],randomFiles[i])
f = open(currentDir+"mod.yml", "w")
f.write(output)
f.close()