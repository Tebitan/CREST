<?php

$service_url = 'http://localhost:1718/api/values/';
$curl = curl_init($service_url);
$curl_post_data = array(
		'Id' => '100',
        'Nombre' => 'Agente',
        'Correo' => 'agent@e.com',
        'Rol' => 'MenInBlack'
);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
curl_setopt($curl, CURLOPT_POST, true);
curl_setopt($curl, CURLOPT_POSTFIELDS, $curl_post_data);
$curl_response = curl_exec($curl);
if ($curl_response === false) {
    $info = curl_getinfo($curl);
    curl_close($curl);
    die('Ocurrio un error: ' . var_export($info));
}
curl_close($curl);
$decoded = json_decode($curl_response);
if (isset($decoded->response->status) && $decoded->response->status == 'ERROR') {
    die('Ocurrio un error: ' . $decoded->response->errormessage);
}
echo 'Guardado en la BD';
?>