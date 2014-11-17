# -*- coding: cp1252 -*-
import urllib, random, urllib2



foo = raw_input('Elija CRUD. Read (HTTP GET):1, Create (HTTP POST):2, Update (HTTP PUT):3, Delete (HTTP DELETE):4\n->')

if foo == '1':
    url = 'http://localhost:1718/api/values'
    u = urllib.urlopen(url)
    # u is a file-like object
    data = u.read()
    print data
    
elif foo == '2':
    name = raw_input('Ingrese Nombre: ')
    mail = raw_input('Ingrese Correo: ')
    role = raw_input('Ingrese Rol: ')
    datos=urllib.urlencode({"Nombre": name ,"Correo" : mail, "Rol": role})
    web=urllib2.urlopen("http://localhost:1718/api/values", datos)
    print('Operación realizada exitosamente')


elif foo == '3':
    id = raw_input('Ingrese Id del contacto')
    name = raw_input('Ingrese titulo del libro: ')
    mail = raw_input('Ingrese autor del libro: ')
    role = raw_input('Ingrese isbn del libro: ')
    datos=urllib.urlencode({"Nombre": name ,"Correo" : mail, "Rol": role})
    web=urllib2.urlopen(("http://localhost:1718/api/values" + str(id), datos)
    print('Operación realizada exitosamente')


elif foo == '4':
    id = raw_input('Ingrese Id -->')
    url= 'http://localhost:1718/api/values' + str(id)
    web=urllib2.urlopen(url)
    print('Operación realizada exitosamente')
