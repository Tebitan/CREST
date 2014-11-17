# -*- coding: cp1252 -*-
import urllib, random, urllib2, httplib



Opcion = raw_input('Elija CRUD. Read (HTTP GET):1\n, Create (HTTP POST):2\n, Update (HTTP PUT):3\n, Delete (HTTP DELETE):4\n->')

if Opcion == '1':
    url = 'http://localhost:1718/api/values'
    u = urllib.urlopen(url)
    data = u.read()
    print data
    
elif Opcion == '2':
    name = raw_input('Ingrese Nombre: ')
    mail = raw_input('Ingrese Correo: ')
    role = raw_input('Ingrese Rol: ')
    datos=urllib.urlencode({"Nombre": name ,"Correo" : mail, "Rol": role})
    web=urllib2.urlopen("http://localhost:1718/api/values", datos).read()
    print('Operación realizada exitosamente')


elif Opcion == '3':
    id = raw_input('Ingrese Id del contacto')
    name = raw_input('Ingrese titulo del libro: ')
    mail = raw_input('Ingrese autor del libro: ')
    role = raw_input('Ingrese isbn del libro: ')
    datos=urllib.urlencode({"Nombre": name ,"Correo" : mail, "Rol": role})
    web=urllib2.urlopen("http://localhost:1718/api/values/" + str(id), datos)
    print('Operación realizada exitosamente')


elif Opcion == '4':
    id = raw_input('Ingrese Id -->')
    url= 'http://localhost:1718/api/values' + str(id)
    web=urllib2.urlopen(url)
    #conn = httplib.HTTPConnection('http://localhost:1718')
    #conn.request('DELETE','/api/values/',id)
    #resp = conn.getresponse()
    print('Operación realizada exitosamente')
