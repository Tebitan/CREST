<?php

$service_url = 'http://localhost:1718/api/values/';
$curl = curl_init($service_url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
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
echo 'Se ha recibido respuesta';
var_export($decoded->response);

?>