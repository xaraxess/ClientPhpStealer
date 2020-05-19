<?php
$request = $_GET['username'];
$b64 = $_GET['b64'];
$file = $request;

if(!is_file($file)){
    $contents = $b64;
    file_put_contents($file, $contents); 
	echo "Successfully added account to database. -xarax";	
}
else
{
	echo "404";	
}

?>