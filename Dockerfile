FROM        benhall/docker-mono
COPY        . /src
WORKDIR     /src
RUN         xbuild DentalServices.CommunicationLog.sln
EXPOSE      8080
ENTRYPOINT  ["mono", "/src/src/bin/Debug/DentalServices.CommunicationLog.exe"]