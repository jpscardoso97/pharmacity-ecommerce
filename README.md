# Applying "A Guide for Microservices in Greenfield Projects"

## Problem
As more companies adopt a microservice-based architecture for their applications, there is a question that still does not have a consensual answer: should an application based on microservices be built from scratch or start as a monolithic application, to be then broken into smaller blocks? Even though the approach that follows the “conventional wisdom” (Zdun et al., 2020) is to start with a monolithic application (Fowler, 2015), building a monolithic system considering that it will later migrate to microservices and preparing it for a linear transition has been seen as a challenge (Zdun et al., 2020).
There are many examples of migrations from a monolithic architecture to a microservice architecture (Nguyen, 2020) (Bucchiarone et al., 2018) (Bjørndal et al., 2020), but very little for other approaches (Lumetta, n.d.). More unconventional approaches such as starting with microservices were not sufficiently explored, and reported experiences lack to guide the entire process. Therefore, the problem to be addressed in this work is how to start with microservices from scratch. It will contribute to the field with a documented experience available to the entire community. This will enable its replication and improvement in future developments and projects.


## Context
The project is developed in the scope of the MSc in Software Engineering in ISEP. 
During this dissertation I've designed a set of guidelines to facilitate the development of microservices in Greenfield projects. Following the Technical Action Research (TAR) method (find more [here](http://rcis-conf.com/rcis2012/document/slides/RCIS12_TechnicalActionResearch.pdf)), the designed artifacts needed to be applied to a realistic scenario. It was found as an oportunity that a business area that could benefit from this work was (Community Pharmacy Systems), thus, a prototype was implemented. An interview with a person in the industry was conducted to understand which were the major concerns of the existing systems so that they can be tackled on the prototype and its development is registered in this repository.

## Pharmacity E-Commerce Module

This repository includes all the artifacts and source code of a greenfield project based in microservices for community pharmacy systems.

## Contributions

The designed artifact will be publicly accessible once it it presented in ISEP, and will be made available here.
It is expected that every software developer is able to contribute to the project suggesting corrections and additional steps to the guide, as well as contributing to the prototype. For that a fork of this repository should be created and a pull-request should be made with all the necessary documentation with the rationale behind it.
