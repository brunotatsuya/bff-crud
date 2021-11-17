from flask import Flask, jsonify, render_template

app = Flask(__name__, template_folder='templates')

@app.route('/DebugDROpy')
def DebugDROpy():
    return render_template('DebugDROpy.html')

@app.route('/Controle')
def Controle():
    return render_template('Controle.html')

app.run()