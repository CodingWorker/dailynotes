import sun.plugin.com.AmbientProperty;

import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;

/**
 * Created by DaiYan on 2017/4/26.
 */
public class Demo {
    public static void main(String[] args){
     //hashmap实例
        Map<Integer,String> map=new HashMap<>();
        map.put(1,"banana");
        map.put(6,"apple");
        map.put(3,"peach");

        for(Integer key :map.keySet()){
            System.out.println("key: "+key+" ,value: "+map.get(key));
        }
        /**
         * 输出结果为：1 3 6
         * 实际上hashmap是按照hashcode来存储数据的。它的元素是没有顺序的，可能默认是按照键的hashcode的升序来排列的
         */
        //linkedhashmap实例
        Map<Integer,String> map2=new LinkedHashMap<>();
        map2.put(1,"banana");
        map2.put(6,"apple");
        map2.put(3,"peach");
        for(Integer key:map2.keySet())
            System.out.println("key: "+key+", value: "+map2.get(key));

        /**
         * linkedhashmap不会改变插入的顺序，数据按照插入的顺序存储
         */

    }
}
