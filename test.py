import base64


with open("curso_angular.zip", "wb") as f:
    f.write(base64.decodebytes(base64_str))