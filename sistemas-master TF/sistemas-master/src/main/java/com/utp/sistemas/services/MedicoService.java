package com.utp.sistemas.services;

import com.utp.sistemas.entities.Medico;
import com.utp.sistemas.repositories.MedicoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class MedicoService {

    @Autowired
    private MedicoRepository medicoRepository;

    public Medico createMedico(Medico medico) {
        return medicoRepository.save(medico);
    }

    public List<Medico> getAllMedicos() {
        return medicoRepository.findAll();
    }

    public Optional<Medico> getMedicoById(Integer id) {
        return medicoRepository.findById(id);
    }

    public Medico updateMedico(Integer id, Medico medicoDetails) {
        Optional<Medico> medico = medicoRepository.findById(id);
        if (medico.isPresent()) {
            Medico updatedMedico = medico.get();
            updatedMedico.setEmpleado(medicoDetails.getEmpleado());
            updatedMedico.setEspecialidad(medicoDetails.getEspecialidad());
            updatedMedico.setEstado(medicoDetails.getEstado());
            return medicoRepository.save(updatedMedico);
        }
        return null;
    }

    public void deleteMedico(Integer id) {
        Optional<Medico> medico = medicoRepository.findById(id);
        medico.ifPresent(m -> medicoRepository.delete(m));
    }
}