import os
import random

files = os.listdir("CommandMenus")
randomFiles = os.listdir("CommandMenus")
random.shuffle(randomFiles)
output = "assets:\r"
for i in range(len(files)):
    output += "- name: field2d\jp\{0}\r  method: copy\r  source:\r  - name: CommandMenus\{1}\r".format(files[i],randomFiles[i])
f = open("mod.yml", "w")
f.write(output)
f.close()