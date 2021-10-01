package com.mongodb.quickstart;

import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoClients;
import org.bson.Document;

import java.util.ArrayList;
import java.util.List;

public class Connection {

    public static void main(String[] args) {
        String connectionString = System.getProperty("mongodb.uri");
//        System.out.println(connectionString0);
//        String connectionString = "mongodb://localhost:27017";
//        System.setProperty("mongodb.uri", connectionString);
//        Properties props = System.getProperties();
//        props.setProperty("mongodb.uri", connectionString);
        try (MongoClient mongoClient = MongoClients.create(connectionString)) {
            List<Document> databases = mongoClient.listDatabases().into(new ArrayList<>());
            databases.forEach(db -> System.out.println(db.toJson()));
        }
    }
}
