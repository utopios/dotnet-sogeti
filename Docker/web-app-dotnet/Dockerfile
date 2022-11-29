# Image source
FROM ubuntu:20.04
RUN apt update
RUN apt install git wget -y
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb

RUN apt update
RUN apt install dotnet-sdk-6.0 -y