from flask import Flask, json, render_template, send_file, jsonify
from io import BytesIO
import zipfile


app = Flask(__name__, template_folder='templates')

@app.route('/DebugDROpy')
def DebugDROpy():
    return render_template('DebugDROpy.html')

@app.route('/Controle')
def Controle():
    return render_template('Controle.html', 
    tokens=['18763918840f', '187645118840f', '18313513034f', 'e42ef254csd', 
            'e43efcd1csd', 'e43ddee2csd', 'e41134135dwd', 'f1839hdncee3',
            'e13451353dd', '134134314cdf', '12312442dwe', 'f18erqerq31s'])


@app.route('/Get')
def test_download():
    with open(r"C:\Users\tatsuya\Videos\prueba.mkv",'rb') as f:
        g1 = BytesIO(f.read())
    with open(r"C:\Users\tatsuya\Videos\Aut-Sust_1.mkv",'rb') as f:
        g2 = BytesIO(f.read())

    zip_buffer = BytesIO()
    with zipfile.ZipFile(zip_buffer, "a", zipfile.ZIP_DEFLATED, False) as zip_file:
        for file_name, data in [('aaaaaaaa.mkv', g1), ('bbbbb.mkv', g2)]:
            zip_file.writestr(file_name, data.getvalue())
    zip_buffer.seek(0)

    return send_file(zip_buffer, attachment_filename="Captura.zip", as_attachment=True)

app.run()