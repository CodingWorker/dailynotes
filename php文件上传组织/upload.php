<?php

var_dump($_FILES);
/**
 * 输出结果：
 * 这一个多文件数组下的表单项各自成为上传文件超全局数组$_FILES的元素
 */
array (size=1)
  'file' => 
    array (size=5)
      'name' => 
        array (size=2)
          0 => string '3-1.c' (length=5)
          1 => string '6-5.c' (length=5)
      'type' => 
        array (size=2)
          0 => string 'application/octet-stream' (length=24)
          1 => string 'application/octet-stream' (length=24)
      'tmp_name' => 
        array (size=2)
          0 => string 'D:\xampp\tmp\php81C0.tmp' (length=24)
          1 => string 'D:\xampp\tmp\php81D1.tmp' (length=24)
      'error' => 
        array (size=2)
          0 => int 0
          1 => int 0
      'size' => 
        array (size=2)
          0 => int 245
          1 => int 405