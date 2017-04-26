package demo1;

import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by DaiYan on 2017/4/26.
 */
public class Demo {
    public static void main(String[] args){
        //sychronizedMap是线程安全的，但是会影响性能
        Map<String,String> map=Collections.synchronizedMap(new HashMap<String,String>());
    }
}
