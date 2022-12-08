<?php
    include_once('connection.php');

    $registerUser = $_POST["registerUser"];
    $registerPass = $_POST["registerPass"];
    $sql = "SELECT username FROM users WHERE username = '" . $registerUser . "'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        echo "Username is already taken";
    } else {
        $sql = "INSERT INTO users (username, password, level, score) VALUES ('".$registerPass."', '".$registerPass."', 1, 0)";
        if($conn->query($sql)=== TRUE){
            echo "New user is created!";
        }else{
            echo "Error " . $sql . "<br>" . $conn->error;
        }
    }
    $conn->close();
    ?>