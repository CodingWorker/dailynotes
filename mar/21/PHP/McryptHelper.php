<?php 
class McryptHelper{
	public $key = 'uageniustofindit';
	public $padkey = ''; 
	public function __construct(){
		$this->padkey = $this->pad2Length($this->key,16);
	}
	
	public function encrypt($data){
		$cipher = mcrypt_module_open(MCRYPT_RIJNDAEL_128, '', MCRYPT_MODE_ECB, ''); 
		$iv_size = mcrypt_enc_get_iv_size($cipher);
	    $iv = mcrypt_create_iv($iv_size, MCRYPT_RAND); #IV自动生成
		if (mcrypt_generic_init($cipher, 'adaf', $iv) != -1) 
		{
			// PHP pads with NULL bytes if $content is not a multiple of the block size.. 
			$block_size = $this->pad2Length($data,16);
			$cipherText = mcrypt_generic($cipher,$block_size ); 
			
			mcrypt_generic_deinit($cipher); 
			mcrypt_module_close($cipher); 
		}

		return base64_encode($cipherText);
	}
	
	public function decrypt($data){
		$mw = base64_decode($data);
		$td = mcrypt_module_open(MCRYPT_RIJNDAEL_128, '', MCRYPT_MODE_ECB, ''); 
		if (mcrypt_generic_init($td, $this->$padkey, $iv) != -1) 
		{ 
			$p_t = mdecrypt_generic($td, $mw); 
			
			mcrypt_generic_deinit($td); 
			mcrypt_module_close($td); 
		} 

		return $p_t;
	}

	//将$text补足$padlen倍数的长度 
	public function pad2Length($text, $padlen){ 
		$len = strlen($text)%$padlen; 
		$res = $text; 
		$span = $padlen-$len; 
		for($i=0; $i<$span; $i++){ 
			$res .= chr($span); 
		} 
		
		return $res; 
	} 

	//将解密后多余的长度去掉(因为在加密的时候 补充长度满足block_size的长度) 
	public function trimEnd($text){ 
		$len = strlen($text); 
		$c = $text[$len-1];
		//print($text);die;
		//print($len);16
	//	print(ord($c));//11
		if(ord($c) <$len){ 
			for($i=$len-ord($c); $i<$len; $i++){   //这个去掉后面多余的长度的原来是根据pad2Length来做的，因为pad2Length就是在最后添加bloc_size-要加密的文本的长度的值表示的字符；所以最后要去掉
				//print($text[$i] . "\r\n");
				if($text[$i] != $c){ 
					return $text; 
				} 
			} 
			return substr($text, 0, $len-ord($c)); 
		} 
		return $text; 
	}

	//16进制的转为2进制字符串 
	public function hexToStr($hex) 
	{ 
		$bin=""; 
		for($i=0; $i<strlen($hex)-1; $i+=2) 
		{ 
			$bin.=chr(hexdec($hex[$i].$hex[$i+1])); 
		} 
		return $bin; 
	} 

}
$m = new McryptHelper();
$data = '案:<?php/***byte数组与字符串转化类*/classBy';
var_dump($m->encrypt($data));


