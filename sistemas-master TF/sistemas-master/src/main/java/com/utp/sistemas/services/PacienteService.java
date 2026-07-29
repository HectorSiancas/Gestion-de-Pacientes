package com.utp.sistemas.services;

import com.utp.sistemas.entities.Paciente;
import com.utp.sistemas.repositories.PacienteRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class PacienteService {

    @Autowired
    private PacienteRepository pacienteRepository;

    public Paciente createPaciente(Paciente paciente) {
        return pacienteRepository.save(paciente);
    }

    public List<Paciente> getAllPacientes() {
        return pacienteRepository.findAll();
    }

    public Optional<Paciente> getPacienteById(Integer id) {
        return pacienteRepository.findById(id);
    }

    public Paciente updatePaciente(Integer id, Paciente pacienteDetails) {
        Optional<Paciente> paciente = pacienteRepository.findById(id);
        if (paciente.isPresent()) {
            Paciente updatedPaciente = paciente.get();
            updatedPaciente.setNombres(pacienteDetails.getNombres());
            updatedPaciente.setApPaterno(pacienteDetails.getApPaterno());
            updatedPaciente.setApMaterno(pacienteDetails.getApMaterno());
            updatedPaciente.setEdad(pacienteDetails.getEdad());
            updatedPaciente.setSexo(pacienteDetails.getSexo());
            updatedPaciente.setNroDocumento(pacienteDetails.getNroDocumento());
            updatedPaciente.setDireccion(pacienteDetails.getDireccion());
            updatedPaciente.setTelefono(pacienteDetails.getTelefono());
            updatedPaciente.setEstado(pacienteDetails.getEstado());
            updatedPaciente.setImagen(pacienteDetails.getImagen());
            return pacienteRepository.save(updatedPaciente);
        }
        return null;
    }

    public void deletePaciente(Integer id) {
        Optional<Paciente> paciente = pacienteRepository.findById(id);
        paciente.ifPresent(p -> pacienteRepository.delete(p));
    }
}

